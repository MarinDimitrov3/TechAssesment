How to connect to Mongo cluster:
Email to use : HavingFunWithMongo@gmail.com
password to use : mongodbiscool
To check the logged data, please, go to Database -> Browse Collections -> GetCreditCardOffersLogs

TODO: I would definitely index the collection on Request.RequestBody.FirstName and LastName to find the info faster as in a production
environment there will be a lot of data.

GitHub Repo : https://github.com/MarinDimitrov3/TechAssesment

You can just pull and run the solution. Should be done in .NET 6 VS 2022.



ConnectionString storage:
Atm the connection string was included within appsettings.json and is accessed through IConfiguration, but that is no considered safe enough.
For dev purposes it could be included as a secret, while in production it depends. In Azure devops within releases it could be inserted 
and then hidden, Azure Key Vault could also be considered.

Logging:
If it was a production Api I would definitely add logging by dependency injecting ILogger. I may go for Serilog as I have used it before
and it could be integrated with Teams so if an error occurs it direcly logs into a teams channel.

Exception Handling:
Depending on the code I may create custom exceptions and catching and reacting to each one specifically.

Versioning:
Atm the api has only one version. If a second version of the given controller is created it could potentially inherit from it and override the methods.
It would be shown in swagger as atm I specified the option of second version.

Database connection:
Since Mongo (especially free clusters) could be slow I may add a retry logic to retry a few times to if a message is timing out. Would add logging if there are
connection problems to the database.

Testing:
May include integration tests by using UseTestServer to test the Middleware and how it responds to different requests.
Further testing could be done with tools such as JMeter (load testing for instance).

Post vs Get
I am aware that getting values using some inputs usually could be done with a Get request and that post is usually for creating new instances within a database
from example. But I chose to use a POST request as the data contains client name. Post is usually considered safer than Get in similar situations.

Example curl
curl -X 'POST' \
  'https://localhost:7228/api/v1/CreditCardDecision/GetCreditCardOffers' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "firstName": "string",
  "lastName": "string",
  "dateOfBirth": "2022-03-08T23:33:01.326Z",
  "annualIncome": 99999999999.99
}'
