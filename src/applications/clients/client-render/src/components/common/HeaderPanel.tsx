import {theme, Typography} from "antd";
import {Header} from "antd/es/layout/layout";
import {LoginOutlined} from "@ant-design/icons";
import {IUserInfo} from "../../models/Identity.ts";
import styles from './styles/HeaderPanel.module.css'
import {WebApiClients} from "../../clients/webApiClients.ts";
import {useState} from "react";
import {RouteViews} from "../../modules/RouteConfig.tsx";
import {Navigate} from "react-router-dom";
import {CompactLogo} from "./LogoComponents.tsx";

const { useToken } = theme;

export const HeaderPanel = ({ user } : {user : IUserInfo}) => {
    const { token } = useToken()
    const [logout, setLogout] = useState(false)

    const clickLogout = () => {
        WebApiClients.logoutAsync()
            .then(value => console.log(value))

        setLogout(true)
    }

    if (logout){
        return <Navigate to={RouteViews["main"]} replace/>
    }

    return (
        <Header className={styles.main_header}
                style={{backgroundColor: token.colorBgContainer, boxShadow: '0px 5px 5px 0px rgba(34, 60, 80, 0.1)' }}
        >

            <span>
                <CompactLogo height={'60px'} width={'60px'} textColor={token.colorTextBase}/>
            </span>

            <span>
                <Typography.Text type={"secondary"} style={{marginRight: '10px'}}>
                    {user.email}
                </Typography.Text>

                <a onClick={clickLogout}>
                    <LoginOutlined alt={"logout"}/>
                </a>
            </span>

        </Header>
    );
};