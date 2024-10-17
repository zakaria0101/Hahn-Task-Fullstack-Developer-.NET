import { Component, EventEmitter, Input, Output } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Ticket } from '../../Models/Ticket';
import { CommonModule } from '@angular/common';
import { TicketService } from '../../services/ticket.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-ticket-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  providers: [TicketService],
  templateUrl: './ticket-form.component.html',
  styleUrls: ['./ticket-form.component.scss'],
})
export class TicketFormComponent {
  @Input() ticket: Ticket | null = null;
  @Output() close = new EventEmitter<void>();

  ticketForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private ticketService: TicketService,
    private toastr: ToastrService
  ) {
    this.ticketForm = this.fb.group({
      description: ['', Validators.required],
      status: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    if (this.ticket) {
      this.ticketForm.patchValue(this.ticket);
    }
  }

  onSave(): void {
    if (this.ticketForm.valid) {
      console.log('Form data:', this.ticketForm.value);
      if (this.ticket) {
        this.ticketService
          .updateTicket(this.ticket.ticket_ID, this.ticketForm.value)
          .subscribe(() => {
            this.toastr.info('Ticket updated successfully!', 'Info');
            this.resetForm();
            this.close.emit();
          });
      } else {
        this.ticketService.createTicket(this.ticketForm.value).subscribe(() => {
          this.toastr.success('Ticket added successfully!', 'Success');
          this.close.emit();
          this.resetForm();
        });
      }
    } else {
      this.markAllAsTouched();
      console.log('Form is invalid', this.ticketForm.errors);
    }
  }

  onCancel(): void {
    this.close.emit();
    this.resetForm();
  }

  private resetForm(): void {
    this.ticketForm.reset();
    this.ticket = null;
  }
  private markAllAsTouched(): void {
    Object.keys(this.ticketForm.controls).forEach((field) => {
      const control = this.ticketForm.get(field);
      control?.markAsTouched({ onlySelf: true });
    });
  }
}
