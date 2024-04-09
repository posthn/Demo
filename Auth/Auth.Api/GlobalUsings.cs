global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using Demo.Auth.Domain.Models;
global using Demo.Auth.Domain;
global using Demo.Core.Domain.Exceptions;
global using Demo.Auth.EntityFramework;
global using Demo.Core.Api.RequestsPool.Auth.Create;
global using Demo.Core.Api.RequestsPool.Auth.Update;
global using Demo.Core.Api.EventsPool.Users;
global using Demo.Core.Api.ResponsesPool.Auth;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.Extensions.DependencyInjection;



