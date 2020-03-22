using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Enums
{
	public enum StatusCode : int
	{
		OK = 200,
		SeeException = 303,
		Banned = 402,
		Forbidden = 403,
		NotFound = 404,
		Timeout = 408,
		InternalError = 500,
		NotValidId = 600,
		AlreadyExists = 603,
		InvalidInput = 605,
		NotEnabled = 607,
		EmailNotConfirmed = 608,
		WrongPassword = 610,
		NoPassword = 611,
		ExpiredPassword = 613,
		InsufficientPermissions = 615,
		CannotTransfer = 617,
		CannotSplit = 618,
		JustALittleError = 620,
	}
}