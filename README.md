beddit.net
==========

C# Library to aid in accessing the beddit.com [API](https://github.com/beddit/beddit-api).

Authorization/Tokens
==========
Only user level authorization has been implemented and thus only user tokens are returned from authorization.
This also means that currently that Password Reset is not implemented.

Error Handling
==========
Only very limited error handling has been implemented so far. 

Testing
==========
There is a small test suite that tests directly against the API. To use, modify the app.config key values 
for your username and password. The tests also assume you have some sleep data from the last two days.



