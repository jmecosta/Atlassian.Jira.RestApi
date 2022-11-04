using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Atlassian.Jira.Remote;

namespace Atlassian.Jira
{
    /// <summary>
    /// The resolution of the issue as defined in JIRA
    /// </summary>
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public class IssueResolution : JiraNamedEntity
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
    {
        /// <summary>
        /// Creates an instance of the IssueResolution based on a remote entity.
        /// </summary>
        public IssueResolution(AbstractNamedRemoteEntity remoteEntity)
            : base(remoteEntity)
        {
        }

        /// <summary>
        /// Creates an instance of the IssueResolution with the given id and name.
        /// </summary>
        public IssueResolution(string id, string name = null)
            : base(id, name)
        {
        }

        protected override async Task<IEnumerable<JiraNamedEntity>> GetEntitiesAsync(Jira jira, CancellationToken token)
        {
            var results = await jira.Resolutions.GetResolutionsAsync(token).ConfigureAwait(false);
            return results as IEnumerable<JiraNamedEntity>;
        }

        /// <summary>
        /// Allows assignation by name
        /// </summary>
        public static implicit operator IssueResolution(string name)
        {
            if (name != null)
            {
                int id;
                if (int.TryParse(name, out id))
                {
                    return new IssueResolution(name /*as id*/);
                }
                else
                {
                    return new IssueResolution(null, name);
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
        public static bool operator ==(IssueResolution entity, string name)
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
        public static bool operator !=(IssueResolution entity, string name)
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
