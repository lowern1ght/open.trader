import {AccountForm} from "../components/common/AccountForm.tsx";
import {LoginComponent} from "../components/account/LoginComponent.tsx";
import {ThemeSwitcher} from "../components/account/ThemeSwitcher.tsx";

export const LoginPage = () => {
    return (
        <AccountForm>
            <ThemeSwitcher/>
            <LoginComponent/>
        </AccountForm>
    );
};