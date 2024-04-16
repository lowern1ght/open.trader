import {useState} from "react";
import {Link, Navigate} from "@tanstack/react-router";
import accountStyles from "../styles/Account.module.css"
import {IRegisterModel} from "../../models/identity.ts";
import {Button, Card, Divider, Form, Input, Layout, Spin, Typography} from "antd";
import {LockOutlined, MailOutlined, UserOutlined} from "@ant-design/icons";
import {ThemeSwitcher} from "../decoration/ThemeSwitcher.tsx";
import {useDocumentTitle} from "@uidotdev/usehooks";
import {titleWith} from "../../utilities.ts";

const passwordValidator = ({getFieldValue} : {getFieldValue: (param: string) => string }) => ({ validator(_: unknown, value: unknown) {
    if (!value || getFieldValue('password') === value) {
        return Promise.resolve();
    }

    return Promise.reject(new Error('The new password that you entered do not match!'));
}});

export const RegisterComponent = () => {
    const [loading, setLoading] = useState(false)
    const [isRegistered, setRegister] = useState(false)

    useDocumentTitle(titleWith('register'))
    
    const onFinish = async (model: IRegisterModel) => {
        setLoading(true)

        setRegister(true);

        console.log(model)
        
        /*IdentityClient.registerAsync(model)
            .then(_ => setRegister(true))*/
        
        setLoading(false)
    }

    if (isRegistered) {
        return <Navigate to={'/'} replace={true}/>
    }
    
    return (
        <Layout className={accountStyles.back} style={{zIndex: 1}}>
            <ThemeSwitcher/>
            <Card className={accountStyles.form}>
                <Spin spinning={loading} size={"large"}>

                    <Typography.Title className={accountStyles.title_text}>
                        Register In
                    </Typography.Title>

                    <Form
                        name="normal_login"
                        className="login-form"
                        style={{width: 250}}
                        initialValues={{ remember: true }}
                        onFinish={onFinish}
                    >
                        <Form.Item
                            name="email"
                            rules={[{ required: true, message: 'Please input your Email!' }]}
                        >
                            <Input prefix={<MailOutlined className="site-form-item-icon" />} placeholder="Email" />
                        </Form.Item>

                        <Form.Item
                            name="username"
                            rules={[{ required: true, message: 'Please input your Username!' }]}
                        >
                            <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Username" />
                        </Form.Item>

                        <Form.Item
                            name="password"
                            rules={[{ required: true, message: 'Please input your Password!' }]}
                        >
                            <Input
                                prefix={<LockOutlined className="site-form-item-icon" />}
                                type="password"
                                placeholder="Password"
                            />
                        </Form.Item>

                        <Form.Item
                            name="passwordConfirm"
                            rules={[ {required: true, message: 'Please input Password!'}, passwordValidator]}
                        >
                            <Input
                                prefix={<LockOutlined className="site-form-item-icon" />}
                                type="password"
                                placeholder="Confirm password"
                            />
                        </Form.Item>

                        <Divider style={{margin: 10}}/>

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
                                Register
                            </Button>

                            <Typography.Text style={{height: 'auto'}}>
                                Or
                            </Typography.Text>

                            <Link to={'/account/login'}>login now</Link>
                        </div>
                    </Form>
                </Spin>
            </Card>
        </Layout>
    )
};