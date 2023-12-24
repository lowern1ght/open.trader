import styles from "./styles/NotFound.module.css"
import {Link} from "react-router-dom";
import {Button, Layout, Typography} from "antd";

export const NotFound = () => {
    return (
        <Layout className={styles.main}>

            <div className={styles.container}>
                <Typography.Text className={styles.not_found_text}>Not Found</Typography.Text>
                <Typography.Text className={styles.not_found_description_text}>
                    Unfortunately the page you wanted to go to exists
                </Typography.Text>

                <Link to={"/"}>
                    <Button size={"large"} className={styles.button} type={"primary"}>
                        To Home
                    </Button>
                </Link>

            </div>
        </Layout>
    );
};