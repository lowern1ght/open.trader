import { createLazyFileRoute } from '@tanstack/react-router'
import {ApplicationComponent} from "../components/ApplicationComponent.tsx";

export const Route = createLazyFileRoute('/')({
  component: () => <ApplicationComponent/>
})