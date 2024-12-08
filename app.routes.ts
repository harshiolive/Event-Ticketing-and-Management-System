import { Routes } from '@angular/router';
import { LayoutComponent } from './pages/layout/layout.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { Login, LoginComponent } from './pages/login/login.component';
import { MainpageComponent } from './pages/mainpage/mainpage.component';
import { EventsComponent } from './pages/events/events.component';
import { SignupComponent } from './pages/signup/signup.component';
import { PaymentComponent } from './pages/payment/payment.component';
import { BookticketsComponent } from './pages/booktickets/booktickets.component';
import { SeatingComponent } from './pages/seating/seating.component';

export const routes: Routes = [
    {
        path:'', component:MainpageComponent, pathMatch:'full'
    },
    {
        path:'login', component:LoginComponent
    },
    {
        path:'events', component:EventsComponent
    },
    {
        path:'signup', component:SignupComponent
    },
    {
        path:"payment", component:PaymentComponent
    },
    {
        path:"booktickets", component:BookticketsComponent
    },
    {
        path:"seating", component:SeatingComponent
    },
    {
        path:'mainpage',
        component:MainpageComponent,
        children:[
            {
                path:'Login',
                component:LoginComponent
            }
        ]
    },
    {
        path:'',
        component:LayoutComponent,
        children:[
            {
                path:'dashboard',
                component:DashboardComponent
            }
        ]
    }
];
