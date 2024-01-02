import Sider from "antd/es/layout/Sider";
import {Content} from "antd/es/layout/layout";
import styles from './styles/PannelComponent.module.css'
import {Card, ConfigProvider, Layout, ModalFuncProps, Typography} from "antd";
import {GlobalConfigProvider, globalTheme} from "../modules/GlobalConfig.ts";

// @ts-ignore
const configModal : ModalFuncProps = {
    title: "Alpha version",
    content: 'This version is not release, maybe there will be bugs) \n Enjoy your use',
    centered: true,
    width: "450px"
}

export const PanelComponent = () => {
    return (
        <ConfigProvider theme={globalTheme}>
            <Layout className={styles.panel}>

                <Layout hasSider={true}>

                    <Sider collapsed theme={GlobalConfigProvider.isDark() ? "dark" : "light"}>

                    </Sider>

                    <Content style={{padding: '20px'}}>
                        <Card>
                            <Typography.Title type={"danger"}>

                            </Typography.Title>
                        </Card>
                    </Content>
                </Layout>

            </Layout>
        </ConfigProvider>
    );
};