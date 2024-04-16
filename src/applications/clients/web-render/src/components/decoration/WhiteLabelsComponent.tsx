import {Typography} from "antd";
import {Link} from "@tanstack/react-router";
import styles from '../styles/Logo.module.css'
import logoSvg from "../../assets/max_icon.svg";

export const LogoComponent = ({ size, withDivide = false } : { size: string, withDivide: boolean }) => {
    return (
        <Link to={'/'}>
            <div style={{height: size}} className={styles.general}>
                <img src={logoSvg} alt="logo" style={{height: size, width: size}}/>
                <Typography.Text color={"neutral"} className={styles.text}>
                    Trader
                </Typography.Text>
                {
                    withDivide
                        ? <>
                            <Typography.Text className={styles.text}
                                             style={{marginLeft: '8px', marginRight: '8px', opacity: '0.5'}}>|
                            </Typography.Text>
                            <Typography.Text className={styles.text} style={{color: '#ff0073'}}>
                                Platform
                            </Typography.Text>
                          </>
                        : <></>
                }
            </div>
        </Link>
    );
};

export const CompactLogo = ({height, width, textColor}: { height: string, width: string, textColor: string }) => {
    return (
        <div style={{height}} className={styles.compact}>
            <img src={logoSvg} alt="logo" style={{height, width}}/>
            <Typography.Text color={textColor} className={styles.text}>Trader</Typography.Text>
        </div>
    );
};