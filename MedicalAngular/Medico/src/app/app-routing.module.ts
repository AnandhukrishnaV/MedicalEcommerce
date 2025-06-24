import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CartComponent } from './cart/cart.component';
import { AuthGuard } from './Guard/auth.guard';
import { HomeComponent } from './home/home.component';
import { MediloginComponent } from './medilogin/medilogin.component';

const routes: Routes = [
  {path:'',component:MediloginComponent},
  {path:'home',component:HomeComponent,canActivate:[AuthGuard]},
  {path:'cart',component:CartComponent},
  {path:'medilogin',component:MediloginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
