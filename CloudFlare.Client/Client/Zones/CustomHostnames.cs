﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Helpers;

namespace CloudFlare.Client.Client.Zones
{
    public class CustomHostnames : ApiContextBase<IConnection>, ICustomHostnames
    {
        public CustomHostnames(IConnection connection) : base(connection)
        {

        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> AddAsync(string zoneId, string hostname, CustomHostnameSsl ssl, CancellationToken cancellationToken = default)
        {
            var customHostname = new NewCustomHostname
            {
                Hostname = hostname,
                Ssl = ssl
            };

            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{CustomHostnameEndpoints.Base}";
            return await Connection.PostAsync<CustomHostname, NewCustomHostname>(requestUri, customHostname, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> DeleteAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{CustomHostnameEndpoints.Base}/{customHostnameId}";
            return await Connection.DeleteAsync<CustomHostname>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, CustomHostnameFilter filter = null, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
        {
            var builder = new ParameterBuilderHelper();

            builder
                .InsertValue(Filtering.Id, filter?.CustomHostnameId)
                .InsertValue(Filtering.Hostname, filter?.Hostname)
                .InsertValue(Filtering.Order, filter?.OrderType)
                .InsertValue(Filtering.Ssl, filter?.Ssl ?? false ? 1 : 0)
                .InsertValue(Filtering.Page, displayOptions?.Page)
                .InsertValue(Filtering.PerPage, displayOptions?.PerPage)
                .InsertValue(Filtering.Direction, displayOptions?.Order);

            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{CustomHostnameEndpoints.Base}?{builder.ParameterCollection}";
            return await Connection.GetAsync<IReadOnlyList<CustomHostname>>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> GetDetailsAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{CustomHostnameEndpoints.Base}/{customHostnameId}";
            return await Connection.GetAsync<CustomHostname>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> UpdateAsync(string zoneId, string customHostnameId, ModifiedCustomHostname modifiedCustomHostname, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{CustomHostnameEndpoints.Base}/{customHostnameId}";
            return await Connection.PatchAsync<CustomHostname>(requestUri, PatchContentHelper.Create(modifiedCustomHostname), cancellationToken).ConfigureAwait(false);
        }
    }
}