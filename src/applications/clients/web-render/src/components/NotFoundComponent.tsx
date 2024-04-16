import {Link} from "@tanstack/react-router";
import {FrownOutlined} from "@ant-design/icons";
import styles from "./styles/NotFound.module.css"
import {Button, Flex, Layout, Result} from "antd";

export interface NotFoundProps {
    readonly title : string
    readonly message: string
    readonly buttonTitle: string,
    readonly pathToReturn: string,
}

export const NotFound = ({ title, message, pathToReturn, buttonTitle } : NotFoundProps ) => {
    return (
        <Layout className={styles.main}>
            <Flex flex={"auto"} justify={"center"} align={"center"}>
                <Result
                    title={title}
                    status={"error"}
                    subTitle={message}
                    icon={<FrownOutlined/>}
                    extra={[
                        <Link key={'return'} to={pathToReturn}>
                            <Button>{buttonTitle}</Button>
                        </Link>
                    ]}
                />
            </Flex>
        </Layout>
    );
};