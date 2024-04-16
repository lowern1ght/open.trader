import {Content} from "antd/es/layout/layout";
import styles from "./styles/LoadingStyles.module.css"
import logoPreview from "../assets/max_icon.svg"
import {LoadingOutlined} from "@ant-design/icons";
import {Layout, Space, Spin, Typography} from "antd";

export const LoadingComponent = () => {
    return (
        <Layout className={styles.main} title={"Open trader"}>
            <Content>
                <Space direction={"vertical"} align={"center"}>
                    <div className={styles.logo_container}>
                        <img src={logoPreview} alt="logo" className={styles.logo}/>
                        <Typography.Text color={"neutral"} className={styles.logo_text}>Trader</Typography.Text>
                        <Typography.Text className={styles.divide}>|</Typography.Text>
                        <Typography.Text className={styles.platform}>Platform</Typography.Text>
                    </div>
                    <div style={{width: '100%'}}>
                        <Spin className={styles.spin} indicator={<LoadingOutlined className={styles.loading_icon} />} spinning/>
                    </div>
                </Space>
            </Content>

            <Space direction={"vertical"} align={"center"} className={styles.copyright_section}>
                <Typography.Text color={"neutral"} className={styles.version}>
                    Beta {import.meta.env.TRADER_REACT_APP_VERSION}
                </Typography.Text>
                
                <Typography.Text className={styles.copyright}>
                    © 2023 OpenTrader - All Rights Reserved.
                </Typography.Text>
            </Space>
        </Layout>
    );
};