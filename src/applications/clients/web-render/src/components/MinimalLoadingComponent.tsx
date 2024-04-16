import {Layout, Spin} from "antd";

export const MinimalLoadingComponent = () => {
    return (
        <Layout style={{ height: '100dvh', width: 'auto' }}>
            <Spin spinning tip={'Loading'} size={"large"} fullscreen/>
        </Layout>
    );
};