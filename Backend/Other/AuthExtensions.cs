using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend.IManagers;
using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Backend.Other
{
	public static class AuthExtensions
	{
		private const string AuthKey = "Authorization";

		private static string GetAuthHeader(this IHeaderDictionary headers)
		{
			if (!headers.TryGetValue(AuthKey, out var token)) {
				return string.Empty;
			}

			var t = token.FirstOrDefault();
			if (string.IsNullOrWhiteSpace(t)) {
				return string.Empty;
			}


			if (t.StartsWith("Bearer ")) {
				t = t.Replace("Bearer ", "");
			}

			return t;
		}

		public static string GetToken(this IHttpContextAccessor context)
		{
			if (context?.HttpContext?.Request == null) {
				return string.Empty;
			}
			var request = context.HttpContext.Request;
			if (request.Cookies.TryGetValue(AuthKey, out string token)) {
				return token;
			}

			return request.Headers?.GetAuthHeader();
		}

		public static void CreateTokenCookie(this IHttpContextAccessor context, string token)
		{
			context?.HttpContext?.Response?.Cookies.Append(AuthKey, token, new CookieOptions {
				Secure = true,
				SameSite = SameSiteMode.None,
				Expires = DateTimeOffset.UtcNow.AddYears(1),
				HttpOnly = true,
				Path = "/"
			});
		}
	}
}