export interface IUserInfo extends IUserDetail {
    id: string
}

export interface ILoginModel
    extends IUserDetail, IPassword
{
    rememberMe: boolean
}

export interface IRegisterModel
    extends IUserDetail, IPassword
{
    passwordConfirm: string
}

export interface IUserDetail {
    email: string
    username: string
}

export interface IPassword {
    password: string
}