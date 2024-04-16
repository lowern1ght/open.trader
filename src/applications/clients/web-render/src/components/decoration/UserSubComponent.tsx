import {useContext} from "react";
import Meta from "antd/es/card/Meta";
import styles from '../styles/UserSub.module.css'
import globalStyles from '../styles/Gradient.module.css'
import {IdentityContext} from "../contexts/IdentityProvider.tsx";
import {Avatar, Button, Card, Popover, Typography, Watermark} from "antd";
import {KeyOutlined, LogoutOutlined, SettingOutlined, UserOutlined} from "@ant-design/icons";

export const UserSubComponent = () => {
    const { user } = useContext(IdentityContext)
    
    if (user == undefined) {
        return <><Avatar>Bad user</Avatar></>
    }
    
    const backgroundComponent = (
        <Watermark
            gap={[15,15]}
            content={'OpenTrader'}
        >
            <div className={ globalStyles.lime + ' ' + styles.user_hover_background}>
                <Typography.Text className={'text-afcad-strong'}>
                    {user.username.length > 30 ? `${user.username.substring(0, 20)}...` : user.username}
                </Typography.Text>
            </div>
        </Watermark>
    )
    
    const content = (
        <Card
            style={{padding: '6px'}}
            cover={backgroundComponent}
            actions={[
                <Button key={'settings'} icon={<SettingOutlined/>}/>,
                <Button key={'security'} icon={<KeyOutlined/>}/>,
                <Button key={'logout'} icon={<LogoutOutlined style={{color: 'red'}}/>}/>
            ]}
        >
            <Meta
                avatar={<Avatar icon={<UserOutlined/>} shape={"circle"}/>}
                title={user.email}
            />
        </Card>
    )
    
    return (
        <Popover content={content}>
            <Avatar size={"default"} icon={<UserOutlined/>}/>
        </Popover>
    );
};