import {SmileOutlined} from "@ant-design/icons";

export const EmptyData = () => {
    return (
        <div style={{ textAlign: 'center', opacity: '0.5' }}>
            <SmileOutlined style={{ fontSize: 20, margin: '20px', }} />
            <p>Empty Data</p>
        </div>
    );
};