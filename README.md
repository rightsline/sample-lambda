# Rightsline Sample Lambda

This is a sample lambda function that is triggered off of an SQS message.  It contains all the AWS signature logic and API code to perform CRUD operations with Rightsline's API.

## Setup
The environment variables include those for the Rightsline API.  Additional variables may be added based on your needs.

**Environment Variables**
- RLACCESSKEY
- RLAPIKEY
- RLAPIURL (no protocol needed, just the host name - api.rightsline.com)
- RLHOST (no protocol needed, just the host name - admin.rightsline.com)
- RLSECRETKEY

## Testing locally with .NET
Use the Tests project to debug through the function.  A sample json message is included and should be updated to match your data for testing.
