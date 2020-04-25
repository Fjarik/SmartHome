using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Enums
{
	public enum StatusCode : int
	{
		OK = 200,
		SeeException = 303,
		Expired = 401,
		NotFound = 404,
		InternalError = 500,
		InvalidId = 600,
		AlreadyExists = 603,
		InvalidInput = 605,
		InsufficientPermissions = 615,
	}
}