using HomeCinema.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace HomeCinema.Web.Infrastructure {
    public static class RequestMessageExtensions {
        internal static IMembershipService GetMembershipService(this HttpRequestMessage request) {
            return request.GetService<IMembershipService>();
        }

        private static TService GetService<TService>(this HttpRequestMessage request) {
            var scope = request.GetDependencyScope();
            var service = (TService)scope.GetService(typeof(TService));
            return service;
        }
    }
}