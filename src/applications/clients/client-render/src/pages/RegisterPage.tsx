import {AccountForm} from "../components/common/AccountForm.tsx";
import {RegisterComponent} from "../components/account/RegisterComponent.tsx";
import {ThemeSwitcher} from "../components/account/ThemeSwitcher.tsx";

export const RegisterPage = () => {
    return (
        <AccountForm>
            <ThemeSwitcher/>
            <RegisterComponent/>
        </AccountForm>
    );
};