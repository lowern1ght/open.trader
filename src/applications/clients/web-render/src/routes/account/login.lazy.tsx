import { createLazyFileRoute } from '@tanstack/react-router'
import {LoginComponent} from "../../components/identity/LoginComponent.tsx";

export const Route = createLazyFileRoute('/account/login')({
  component: () => <LoginComponent/>
})