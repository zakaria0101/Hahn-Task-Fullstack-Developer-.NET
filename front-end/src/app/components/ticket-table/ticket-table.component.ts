import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TicketService } from '../../services/ticket.service';
import { Ticket } from '../../Models/Ticket';
import { TicketFormComponent } from '../ticket-form/ticket-form.component';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { FormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-ticket-table',
  standalone: true,
  imports: [
    CommonModule,
    TicketFormComponent,
    ConfirmationDialogComponent,
    FormsModule,
  ],
  providers: [TicketService],
  templateUrl: './ticket-table.component.html',
  styleUrls: ['./ticket-table.component.scss'],
})
export class TicketTableComponent implements OnInit {
  tickets: Ticket[] = [];
  showModal = false;
  currentTicket: Ticket | null = null;
  filteredTickets: Ticket[] = [];
  searchTerm: string = '';
  sortColumn: keyof Ticket | null = null;
  sortOrder: 'asc' | 'desc' = 'asc';
  showConfirmationDialog = false;
  ticketToDeleteId: number | null = null;

  constructor(
    private ticketService: TicketService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.loadTickets();
  }

  loadTickets(): void {
    this.ticketService.getTickets().subscribe((tickets) => {
      this.tickets = tickets;
      this.filteredTickets = tickets;
      console.log('Tickets loaded:', this.tickets);
    });
  }

  filterTickets(): void {
    this.filteredTickets = this.tickets.filter((ticket) =>
      ticket.description.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
    this.sortFilteredTickets();
  }

  sortTickets(property: keyof Ticket): void {
    this.sortColumn = property;
    this.sortOrder = this.sortOrder === 'asc' ? 'desc' : 'asc';
    this.sortFilteredTickets();
  }

  private sortFilteredTickets(): void {
    if (this.sortColumn) {
      this.filteredTickets.sort((a, b) => {
        const aValue = a[this.sortColumn!];
        const bValue = b[this.sortColumn!];

        if (this.sortOrder === 'asc') {
          return aValue > bValue ? 1 : -1;
        } else {
          return aValue < bValue ? 1 : -1;
        }
      });
    }
  }

  addTicket(): void {
    this.currentTicket = null;
    this.showModal = true;
  }

  editTicket(id: number): void {
    this.currentTicket = this.tickets.find((t) => t.ticket_ID === id) || null;
    this.showModal = true;
  }

  closeModal(): void {
    this.showModal = false;
    this.currentTicket = null;
    this.loadTickets();
  }

  openConfirmationDialog(id: number): void {
    this.ticketToDeleteId = id;
    this.showConfirmationDialog = true;
  }
  confirmDelete(): void {
    if (this.ticketToDeleteId) {
      this.ticketService.deleteTicket(this.ticketToDeleteId).subscribe(() => {
        this.toastr.warning('Ticket deleted successfully!', 'Warning');
        this.loadTickets();
        this.closeConfirmationDialog();
      });
    }
  }

  closeConfirmationDialog(): void {
    this.showConfirmationDialog = false;
    this.ticketToDeleteId = null;
  }
}
