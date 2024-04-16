import {JSX, useEffect, useState} from "react";
import {isIE, isMobile} from "react-device-detect";

export const UnsupportedDetector = ({ mobile, oldBrowser, children } : { children: JSX.Element, oldBrowser?: JSX.Element, mobile?: JSX.Element }) => {
    const [width, setWidth] = useState<number>(window.innerWidth);

    function handleWindowSizeChange() {
        setWidth(window.innerWidth);
    }
    
    useEffect(() => {
        window.addEventListener('resize', handleWindowSizeChange);
        return () => {
            window.removeEventListener('resize', handleWindowSizeChange);
        }
    }, []);

    const isMobileSize = width <= 768;
    
    if (isMobileSize || isMobile && mobile != undefined)
        return mobile;
    
    if (isIE && oldBrowser != undefined)
        return oldBrowser
    
    return children;
};