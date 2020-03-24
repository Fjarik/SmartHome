﻿using System;
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
		public static string GetAuthHeader(this IHeaderDictionary headers)
		{
			var auth = headers.TryGetValue("Authorization", out var token);
			if (!auth) {
				return "";
			}

			var t = token.FirstOrDefault();

			if (string.IsNullOrEmpty(t))
				return "";


			if (t.StartsWith("Bearer ")) {
				t = t.Replace("Bearer ", "");
			}

			return t;
		}

		public static string GetToken(this IHttpContextAccessor context)
		{
			return context.HttpContext?.Request?.Headers?.GetAuthHeader();
		}
	}
}