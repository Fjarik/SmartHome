using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLibrary.Enums;

namespace SharedLibrary.Objects
{
	public class HomeResult<T>
	{
		public T Content { get; set; }

		public Exception Exception { get; set; }
		public bool IsSuccess => (Status == StatusCode.OK && Content != null);
		public StatusCode Status { get; set; }

		public HomeResult() { }

		public HomeResult(StatusCode status) : this(status, default, null) { }

		public HomeResult(StatusCode status, T result) : this(status, result, null) { }

		public HomeResult(StatusCode status, string text) : this(status, new Exception(text)) { }

		public HomeResult(StatusCode status, Exception exception) : this(status, default, exception)
		{
			if (exception == null) {
				throw new ArgumentNullException(nameof(exception), "Exception is null");
			}
		}

		private HomeResult(StatusCode status, T result, Exception exception)
		{
			this.Content = result ?? default(T);

			this.Status = status;
			this.Exception = exception;
		}

		public string GetStatusMessage()
		{
			switch (this.Status) {
				case StatusCode.OK:
					return "Vše v pořádku";
				case StatusCode.SeeException:
					string s = "Vyskytla se chyba";
					if (this.Exception != null) {
						s += $", podrobnosti: {this.Exception.Message}";
					}
					return s;
				case StatusCode.Expired:
					return "Platnost vypršela";
				case StatusCode.NotFound:
					return "Nenalezeno";
				case StatusCode.InternalError:
					return "Vyskytla se chyba na straně serveru";
				case StatusCode.InvalidId:
					return "Poskytnuté ID není platné";
				case StatusCode.AlreadyExists:
					return "Tento záznam již existuje";
				case StatusCode.InvalidInput:
					return "Neplatné vstupní parametry";
				case StatusCode.InsufficientPermissions:
					return "Na tutu akci nemáte dostatečné oprávnění";
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}