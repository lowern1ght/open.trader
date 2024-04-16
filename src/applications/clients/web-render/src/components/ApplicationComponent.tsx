import {Navigate} from "@tanstack/react-router";

const successesResult = () => {
    return <Navigate to={'/exchanges/'} replace={true}/>
}

export const ApplicationComponent = () => {
    return successesResult()
};