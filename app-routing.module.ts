import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { LoginComponent } from './login/login.component';
import { HomepageComponent } from './homepage/homepage.component';
import { NewAccountComponent } from './new-account/new-account.component';
import { ManageBeneficiaryComponent } from './manage-beneficiary/manage-beneficiary.component';
import { DepositComponent } from './deposit/deposit.component';
import { WithdrawalComponent } from './withdrawal/withdrawal.component';
import { FreezeAccountComponent } from './freeze-account/freeze-account.component';


const routes: Routes = [
  {
    path:"",
    component : HomeComponent
  },
  {
    path:"freeze",
    component : FreezeAccountComponent 
  },
  {
    path:"withdrawal",
    component : WithdrawalComponent
  },
  {
    path:"deposit",
    component : DepositComponent
  },
  {
    path:"manage-beneficiary",
    component : ManageBeneficiaryComponent
  },
  
  {
    path:"newaccount",
    component : NewAccountComponent
  },
  {
    path:"homepage",
    component : HomepageComponent
  },
  {
    path:"sidenav",
    component : SidebarComponent
  },
  {
    path:"login",
    component : LoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
