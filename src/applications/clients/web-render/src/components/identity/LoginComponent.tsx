import {useState} from "react";
import {ILoginModel} from "../../models/identity.ts";
import {Link, Navigate} from "@tanstack/react-router";
import accountStyles from "../styles/Account.module.css"
import {LockOutlined, MailOutlined} from "@ant-design/icons";
import {Button, Card, Checkbox, Divider, Form, Input, Layout, notification, Spin, Typography} from "antd";
import {ThemeSwitcher} from "../decoration/ThemeSwitcher.tsx";
import {useDocumentTitle} from "@uidotdev/usehooks";
import {titleWith} from "../../utilities.ts";

const formMessages = {
    email: 'Please input your email',
    password: 'Please input your password',
}

export const LoginComponent = () => {
    const [isLogin, setLogin] = useState(false)
    const [loading, setLoading] = useState(false)
    const [api, contextHolder] = notification.useNotification();

    useDocumentTitle(titleWith('Sign In'))
    
    const onFinish = async (model: ILoginModel) => {
        
        setLoading(true)
        setLogin(true)
        
        api.info({ message: `${JSON.stringify(model)}` })
        
        //Todo: implement login client
        
        /*try {
            IdentityClient.loginAsync(model)
                .then(_ => setLogin(true))
                .catch(reason => console.log(reason))
        }
        catch {
            api.error({
                icon: <FrownOutlined/>,
                message: 'Error sign in',
                description: "Password or Email uncorrected"
            })
        }
        finally {
            setLoading(false)
        }*/
    }

    if (isLogin) {
        return <Navigate to={'/'}/>
    }

    return (
        <Layout className={accountStyles.back}>
            <ThemeSwitcher/>
            <Card className={accountStyles.form}>

                {contextHolder}

                <Spin spinning={loading} size={"large"}>

                    <Typography.Title className={accountStyles.title_text}>
                        Sign In
                    </Typography.Title>

                    <Form
                        name="normal_login"
                        className="login-form"
                        style={{width: 250}}
                        initialValues={{remember: true}}
                        onFinish={onFinish}
                    >
                        <Form.Item
                            name="email"
                            rules={[{required: true, message: formMessages.email}]}
                        >
                            <Input prefix={<MailOutlined className="site-form-item-icon"/>} placeholder="Email"/>
                        </Form.Item>

                        <Form.Item
                            name="password"
                            rules={[{required: true, message: formMessages.password}]}
                        >
                            <Input
                                prefix={<LockOutlined className="site-form-item-icon"/>}
                                type="password"
                                placeholder="Password"
                            />
                        </Form.Item>

                        <Form.Item>
                            <Form.Item name="rememberMe" valuePropName="checked" noStyle>
                                <Checkbox>Remember me</Checkbox>
                            </Form.Item>
                        </Form.Item>

                        <Divider style={{margin: 10}}></Divider>

                        <div style={
                            {
                                display: 'flex',
                                flexDirection: 'row',
                                alignItems: 'center',
                                alignSelf: 'center',
                                justifyContent: 'space-between',
                            }}>

                            <Button
                                type="primary"
                                htmlType="submit"
                                style={{width: 100}}
                                className="login-form-button">
                                Log in
                            </Button>

                            <Typography.Text style={{height: 'auto'}}>
                                Or
                            </Typography.Text>

                            <Link to={'/account/register'}>register now</Link>
                        </div>
                    </Form>
                </Spin>
            </Card>
        </Layout>
    );
};

//<Typography.Link>register now</Typography.Link>