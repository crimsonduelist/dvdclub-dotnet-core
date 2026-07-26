#!/bin/bash
set -e

DIR="$(cd "$(dirname "$0")" && pwd)"
DB="$DIR/DvdClub.Web/dvdclub.db"

if [ -f "$DB" ]; then
    rm -f "$DB" "$DB-shm" "$DB-wal"
    echo "Old database removed."
fi

echo "Building..."
dotnet build "$DIR/DvdClub.Web" --verbosity quiet

echo "Starting server at http://localhost:5052"
dotnet run --project "$DIR/DvdClub.Web" --urls "http://localhost:5052"
