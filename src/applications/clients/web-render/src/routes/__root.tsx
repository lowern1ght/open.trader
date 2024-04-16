import {createRootRoute} from "@tanstack/react-router";
import {NotFound} from "../components/NotFoundComponent.tsx";
import {RootComponent} from "../components/RootComponent.tsx";
import {ErrorComponent} from "../components/ErrorComponent.tsx";

export const Route = createRootRoute({
    component: () => <RootComponent/>,
    notFoundComponent: () => 
        <NotFound
            key={0}
            pathToReturn={'/'}
            title={'Not Found'}
            buttonTitle={'Back to console'}
            message={'Sorry, the page you visited does not exist.'}
        />,
    errorComponent: (props) => <ErrorComponent {...props}/>,
})