﻿namespace CloudFlare.Client
{
    public interface ICloudFlareClient : 
        IDeleteMemberships,
        IGetMemberships,
        IGetMembershipDetails,
        IUpdateMembershipStatus,
        IEditUser,
        IGetUserDetails,
        IVerifyToken,
        IGetAccounts,
        IGetAccountDetails,
        IUpdateAccount,
        IAddAccountMember,
        IDeleteAccountMember,
        IGetAccountMembers,
        IGetAccountMemberDetails,
        IUpdateAccountMember,
        IGetAccountSubscriptions,
        IGetRoles,
        IGetRoleDetails,
        IGetZones,
        ICreateZone,
        IEditZone,
        IDeleteZone,
        IGetZoneDetails,
        IPurgeAllFiles,
        IZoneActivation,
        ICreateDnsRecord,
        IGetDnsRecords,
        IGetDnsRecordDetails,
        IScanDnsRecords,
        IUpdateDnsRecord,
        IDeleteDnsRecord,
        IExportDnsRecord,
        IImportDnsRecords,
        ICreateCustomHostname,
        IGetCustomHostnames,
        IGetCustomHostnamesById,
        IGetCustomHostnameDetails,
        IEditCustomHostname,
        IDeleteCustomHostname
    { }
}
