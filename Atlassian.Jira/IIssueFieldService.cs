﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Atlassian.Jira
{
    /// <summary>
    /// Represents the operations on the issue link types of jira.
    /// </summary>
    public interface IIssueFieldService
    {
        /// <summary>
        /// Returns all custom fields within JIRA.
        /// </summary>
        /// <param name="token">Cancellation token for this operation.</param>
        Task<IEnumerable<CustomField>> GetCustomFieldsAsync(CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Returns custom fields within JIRA given the options specified.
        /// </summary>
        /// <param name="options">Options to fetch custom fields.</param>
        /// <param name="token">Cancellation token for this operation.</param>
        Task<IEnumerable<CustomField>> GetCustomFieldsAsync(CustomFieldFetchOptions options, CancellationToken token = default(CancellationToken));
    }
}
