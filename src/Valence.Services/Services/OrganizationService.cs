using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valence.Repositories;
using Valence.Entities;
using Valence.Models;
using Valence.Interactors;

namespace Valence.Services
{

    public interface IOrganizationService
    {
    }

    public class OrganizationService : ServiceBase ,IOrganizationService
    {
        #region Interactors
        public OrganizationInteractor OrganizationInteractor { get; set; }
        public OrganizationMemberInteractor OrganizationMemberInteractor { get; set; }
        #endregion

        public OrganizationService() {}

        public OrganizationModelList GetContextOrganizations(int ContextMemberId)
        {
            return OrganizationInteractor.GetContextOrganizations(ContextMemberId);
        }

        public void CreateOrganization(int ContextMemberId, OrganizationModel model)
        {
            
            OrganizationInteractor.CreateOrganization(ContextMemberId, model);

            OrganizationMemberModel om = new OrganizationMemberModel();

            om.MemberId = ContextMemberId;
            om.OrganizationId = model.OrganizationId;
            om.OrganizationRoleId = (int)model.ContextRole;
            om.AssignmentTimestamp = DateTime.Now;
            om.EffectiveTimestamp = om.AssignmentTimestamp;

            OrganizationMemberInteractor.CreateOrganizationMember(ContextMemberId, om);

        }


    }
}
