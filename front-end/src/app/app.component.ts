import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TicketTableComponent } from './components/ticket-table/ticket-table.component';
import { TicketService } from './services/ticket.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TicketTableComponent],
  providers: [TicketService],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'Ticket management';
}
