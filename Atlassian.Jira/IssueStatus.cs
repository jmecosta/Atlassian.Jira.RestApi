﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Atlassian.Jira.Remote;

namespace Atlassian.Jira
{
    /// <summary>
    /// The status of the issue as defined in JIRA
    /// </summary>
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public class IssueStatus : JiraNamedConstant
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
    {
        /// <summary>
        /// Creates an instance of the IssueStatus based on a remote entity.
        /// </summary>
        public IssueStatus(RemoteStatus remoteStatus)
            : base(remoteStatus)
        {
            StatusCategory = remoteStatus.statusCategory != null ?
                new IssueStatusCategory(remoteStatus.statusCategory) :
                null;
        }

        internal IssueStatus(string id, string name = null)
            : base(id, name)
        {
        }

        protected override async Task<IEnumerable<JiraNamedEntity>> GetEntitiesAsync(Jira jira, CancellationToken token)
        {
            var results = await jira.Statuses.GetStatusesAsync(token).ConfigureAwait(false);
            return results as IEnumerable<JiraNamedEntity>;
        }

        /// <summary>
        /// The category assigned to this issue status.
        /// </summary>
        public IssueStatusCategory StatusCategory { get; }

        /// <summary>
        /// Allows assignation by name
        /// </summary>
        public static implicit operator IssueStatus(string name)
        {
            if (name != null)
            {
                int id;
                if (int.TryParse(name, out id))
                {
                    return new IssueStatus(name /*as id*/);
                }
                else
                {
                    return new IssueStatus(null, name);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Operator overload to simplify LINQ queries
        /// </summary>
        /// <remarks>
        /// Allows calls in the form of issue.Priority == "High"
        /// </remarks>
        public static bool operator ==(IssueStatus entity, string name)
        {
            if ((object)entity == null)
            {
                return name == null;
            }
            else if (name == null)
            {
                return false;
            }
            else
            {
                return entity.Name == name;
            }
        }

        /// <summary>
        /// Operator overload to simplify LINQ queries
        /// </summary>
        /// <remarks>
        /// Allows calls in the form of issue.Priority != "High"
        /// </remarks>
        public static bool operator !=(IssueStatus entity, string name)
        {
            if ((object)entity == null)
            {
                return name != null;
            }
            else if (name == null)
            {
                return true;
            }
            else
            {
                return entity.Name != name;
            }
        }
    }
}
