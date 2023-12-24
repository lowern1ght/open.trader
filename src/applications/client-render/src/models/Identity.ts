export interface IUserInfo extends IUserDetail {
    id: string
}

export interface IUserLogin
    extends IUserDetail, IPassword
{
    rememberMe: boolean
}

export interface IRegisterModel
    extends IUserDetail, IPassword
{
    confirmPassword: string
}

export interface IUserDetail {
    email: string
    username: string
}

export interface IPassword {
    password: string
}