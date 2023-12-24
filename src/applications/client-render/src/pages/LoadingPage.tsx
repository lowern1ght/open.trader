import {Layout, Space, Spin, Typography} from "antd";
import {Content} from "antd/es/layout/layout";
import logoSvg from "../assets/max_icon.svg";

export const LoadingPage = () => {
    return (
        <Layout className="main" title={"Open trader"}>
            <Content>
                <Space direction={"vertical"} align={"center"}>
                    <div className={"logo-container"}>
                        <img src={logoSvg} alt="logo" className={"logo"}/>
                        <Typography.Text color={"neutral"} className={"logo-text"}>Trader</Typography.Text>
                        <Typography.Text className={"divide"}>|</Typography.Text>
                        <Typography.Text className={"platform"}>Platform</Typography.Text>
                    </div>
                    <div style={{width: '100%'}}>
                        <Spin className={'spin'} spinning delay={500} size={"large"}/>
                    </div>
                </Space>
            </Content>

            <Space direction={"vertical"} align={"center"} className={"copyright"}>
                <Typography.Text className={"copyright"}>
                    © 2023 OpenTrader - All Rights Reserved.
                </Typography.Text>
            </Space>
        </Layout>
    )
}