using Microsoft.AspNetCore.Authorization;

namespace test.Authorization {
    public class HRManagerProbationRequirement : IAuthorizationRequirement {
        public HRManagerProbationRequirement(int probationMonths) {
            ProbationMonths = probationMonths;
        }
        public int ProbationMonths { get; }

        public class HRManagerProbationRequirementHandler : AuthorizationHandler<HRManagerProbationRequirement> {
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HRManagerProbationRequirement requirement) {
                if(!context.User.HasClaim(claim => claim.Type == "EmploymentDate") ) {
                    return Task.CompletedTask;//sometimes we might want to satisfy "one of multiple" requirements
                                              //in that case we dont want to fail the whole policy
                }
                var empDate = DateTime.Parse(context.User.FindFirst(x => x.Type == "EmploymentDate").Value);
                var period = DateTime.Now - empDate;
                if( period.Days > 30 * requirement.ProbationMonths ) {
                    context.Succeed(requirement);
                }
                return Task.CompletedTask;
            }
        }

    }//class
}//namespace
