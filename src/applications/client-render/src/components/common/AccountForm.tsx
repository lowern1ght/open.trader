import {JSX} from "react";
import {Layout} from "antd";
import styles from "./styles/AccountForm.module.css"

export const AccountForm = ({children} : { children: JSX.Element[] }) => (
    <Layout className={styles.back}>
        {children.map(value => value)}
    </Layout>
);