export enum EIdentityTypeOf {
  WelcomeEmailToNewEmployee = 0,
  EmailDeviceNotSeenToOwner = 1,
  EmailDeviceNotSeenToAdmin = 2,
  EmailDeviceNotSeenToMaster = 3,
}

export const EIdentityTypeOfDesc = {
  [EIdentityTypeOf.WelcomeEmailToNewEmployee]:
    "Welcome Email para Novo Usuários",
  [EIdentityTypeOf.EmailDeviceNotSeenToOwner]: "Alerta Equip.Offline p/Dono",
  [EIdentityTypeOf.EmailDeviceNotSeenToAdmin]: "Alerta Equip.Offline p/Admin",
  [EIdentityTypeOf.EmailDeviceNotSeenToMaster]: "Alerta Equip.Offline p/Mestre",
};
