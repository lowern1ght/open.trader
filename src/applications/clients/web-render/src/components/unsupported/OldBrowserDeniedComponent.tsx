import {Flex, Layout, Result} from "antd";
import {IeOutlined} from "@ant-design/icons";
import styles from '../styles/MobileError.module.css'

export const OldBrowserDeniedComponent = () => {
    return (
        <Layout className={styles.layout}>
            <Flex flex={"auto"} justify={"center"} align={"center"} style={{zIndex: 2}}>
                <Result
                    status="error"
                    title="Mobile devices are not supported"
                    subTitle="Use a personal computer or laptop to use OpenTrader"
                    icon={<IeOutlined/>}
                />
            </Flex>
        </Layout>
    );
};