import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user/user.component';
import { AllUsersComponent } from './all-users/all-users.component';


const routes: Routes = [
  { path: 'user/:id', component: UserComponent },
  { path: 'all-users', component: AllUsersComponent },
  { path: '',   redirectTo: '/all-users', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
