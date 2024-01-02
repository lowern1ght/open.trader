import {CSSProperties, useEffect, useState} from "react";
import {IUserInfo} from "../../models/Identity.ts";
import {TraderAuthorizeProvider} from "../account/TraderAuthorizeProvider.tsx";
import {LoginPage} from "../../pages/LoginPage.tsx";
import {LoadingPage} from "../../pages/LoadingPage.tsx";
import {Layout, Space, Button, theme} from "antd";
import {Navigate} from "react-router-dom";
import {RouteViews} from "../../modules/RouteConfig.tsx";
import {IdentityClient} from "../../clients/IdentityClient.ts";
import {HeaderPanel} from "../common/HeaderPanel.tsx";
import Sider from "antd/es/layout/Sider";
import {Content} from "antd/es/layout/layout";
import styles from './styles/ExchangePanel.module.css'
import {generateNeutralColorPalettes} from "antd/es/theme/themes/dark/colors";
import {MenuFoldOutlined, MenuUnfoldOutlined} from "@ant-design/icons";

const { useToken } = theme;
const fullScreen : CSSProperties = {width: '100%', height: '100%'}

const borderRight = (radius: number) : CSSProperties => {
    return {
        borderTopRightRadius: `${radius}px`,
        borderBottomRightRadius: `${radius}px`,
    }
}

const borderLeft = (radius: number) : CSSProperties => {
    return {
        borderTopLeftRadius: `${radius}px`,
        borderBottomLeftRadius: `${radius}px`,
    }
}

export const ExchangePanel = () => {
    const { token } = useToken()
    const [user, setUser] = useState({} as IUserInfo | null)

    useEffect(() => {
        IdentityClient.info()
            .then(value => setUser(value.data))
            .catch(() => setUser(null))
    }, []);

    if (user == null)
        return <Navigate to={RouteViews["login"]}/>

    const [collapsed, setCollapsed] = useState(false)

    return (
        <TraderAuthorizeProvider loginPage={<LoginPage/>} loadingPage={<LoadingPage/>}>
            <Layout style={{...fullScreen}}>
                <HeaderPanel user={user}/>

                <Layout
                    className={styles.back_gradient}
                    style={{...fullScreen, padding: '20px', boxShadow: '0px 5px 5px 0px rgba(34, 60, 80, 0.1)'}}
                >
                    <Sider style={{...borderLeft(6)}} collapsed={collapsed}>

                    </Sider>

                    <Content style={{backgroundColor: token.colorBgContainer, ...borderRight(6)}}>
                        <Space style={{...fullScreen, padding: '10px', alignItems: 'start'}} wrap direction={"horizontal"}>

                            <div style={{width: '100%', height: 32}}>
                                <Button
                                    type="text"
                                    icon={collapsed ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
                                    onClick={() => setCollapsed(!collapsed)}
                                    style={{
                                        fontSize: '16px',
                                        width: 32,
                                        height: 32,
                                    }}
                                />
                            </div>

                        </Space>
                    </Content>
                </Layout>

            </Layout>
        </TraderAuthorizeProvider>
    )
};