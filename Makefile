#Project Variables
PROJECT_NAME ?= SilverTongue
ORG_NAME ?= SilverTongue
REPO_NAME ?= SilverTongue

.PHONY: migrations db

migrations:
	cd ./SilverTongue.Data && dotnet ef --startup-project ../SilverTongue.Web/ migrations add $(mname) && cd ..

db:
	cd ./SilverTongue.Data && dotnetn ef --startup-project ../SilverTongue.Web/ database update && cd .. 
