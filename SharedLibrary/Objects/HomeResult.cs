using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLibrary.Enums;

namespace SharedLibrary.Objects
{
	public class HomeResult<T> where T : class
	{
		public T Content { get; set; }

		public Exception Exception { get; set; }
		public bool IsSuccess => (Status == StatusCode.OK && Content != null);
		public StatusCode Status { get; set; }

		public HomeResult() { }

		public HomeResult(StatusCode status) : this(status, default(T), null) { }

		public HomeResult(StatusCode status, T result) : this(status, result, null) { }

		public HomeResult(StatusCode status, string text) : this(status, new Exception(text)) { }

		public HomeResult(StatusCode status, Exception exception) : this(status, default(T), exception)
		{
			if (exception == null) {
				throw new ArgumentNullException("Exception is null");
			}
		}

		public HomeResult(StatusCode status, T result, Exception exception)
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
				case StatusCode.NoPassword:
					return "Nemáte vytvořené heslo. Použijte funkci zapomenuté heslo";
				case StatusCode.Banned:
					return "Váš účet je zabanován";
				case StatusCode.Forbidden:
					return "Zakázáno";
				case StatusCode.NotFound:
					return "Nenalezeno";
				case StatusCode.Timeout:
					return "Vypršel časový limit na danou operaci";
				case StatusCode.InternalError:
					return "Vyskytla se chyba na straně serveru";
				case StatusCode.NotValidId:
					return "Poskytnuté ID není platné";
				case StatusCode.AlreadyExists:
					return "Tento záznam již existuje";
				case StatusCode.InvalidInput:
					return "Neplatné vstupní parametry";
				case StatusCode.NotEnabled:
					return "Uživatel není aktivovaný";
				case StatusCode.EmailNotConfirmed:
					return "Email není potvrzený";
				case StatusCode.WrongPassword:
					return "Neplatné jméno nebo  heslo";
				case StatusCode.ExpiredPassword:
					return "Zadané heslo již není platné";
				case StatusCode.InsufficientPermissions:
					return "Na tutu akci nemáte dostatečné oprávnění";
				case StatusCode.CannotTransfer:
					return "Vybraného žolíka nelze přenést";
				case StatusCode.CannotSplit:
					return "Vybraného žolík nelze rozdělit";
				case StatusCode.JustALittleError:
					return "Vyskytla se chyba, ale pouze malá :)";
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}