import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TicketFormComponent } from './components/ticket-form/ticket-form.component';
import { TicketTableComponent } from './components/ticket-table/ticket-table.component';

export const routes: Routes = [{ path: '', component: TicketTableComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
