import {ErrorComponentProps, Link} from "@tanstack/react-router";
import {FrownOutlined} from "@ant-design/icons";
import styles from "./styles/NotFound.module.css"
import {Button, Flex, Layout, Result, Typography} from "antd";

export const ErrorComponent = ({ error, reset, info } : ErrorComponentProps ) => {
    reset()
    
    return (
        <Layout className={styles.main}>
            <Flex flex={"auto"} justify={"center"} align={"center"}>
                <Result
                    status={"error"}
                    title={"Unknown error"}
                    icon={<FrownOutlined/>}
                    subTitle={JSON.stringify(error)}
                    extra={[
                        <div>
                            <Typography.Paragraph>
                                {info?.componentStack}
                            </Typography.Paragraph>
                        </div>,
                        <Link to={'/'}>
                            <Button>{'Back to console'}</Button>
                        </Link>
                    ]}
                />
            </Flex>
        </Layout>
    );
};