import { createLazyFileRoute } from '@tanstack/react-router'
import {RegisterComponent} from "../../components/identity/RegisterComponent.tsx";

export const Route = createLazyFileRoute('/account/register')({
  component: () => <RegisterComponent/>
})