var translationsOctDE = {
    //***LABELS***//
    LABEL_LAST_IVOM: 'letzte IVOM',
    LABEL_LAST_OCT: 'letzte OCT',
    LABEL_OCT_DOCTOR: 'OCT Diagnostik Arzt',
    LABEL_TREATMENT_YEAR: 'Behandlungsjahr',
    LABEL_OCTS_PERFORMED: 'OCTs durchgeführt',
    LABEL_OCT_PERFORMED: 'OCT durchgeführt',
    LABEL_NO_OCTS_PERFORMED: 'keine OCTs durchgeführt',
    LABEL_CHANGE_OCT_DOCTOR_POPUP_TITLE: 'Möchten Sie die OCTs einem anderem OCT Diagnostik Arzt zu ordnen?',
    LABEL_WITHDRAW_OCTS_FROM_OTHER_DOCTOR: 'Die OCTs von {{ doctor_name }} sofort zurückzuziehen.',
    LABEL_ALLOW_OCTS_FROM_OTHER_DOCTOR: 'Der bisherige OCT Diagnostik Arzt {{ doctor_name }} soll weitere OCTs bis zum gewähltem Datum abrechnen können: ',
    LABEL_CHANGE_OCT_DOCTOR_POPUP_FOOTER: 'Möchten Sie fortfahren?',
    LABEL_OCT_SUBMITTED: 'Ihre OCTs wurden zur Abrechnung übermittelt.',
    LABEL_OCT: 'OCT',
    LABEL_CHANGE_OCT_DOCTOR_POPUP_CURRENT_OCT_COUNT: 'Es wurden bereits {{current_oct_count}} von {{max_octs}} OCTs durchgeführt.',
    LABEL_CHANGE_OCT_DOCTOR_POPUP_LATEST_OCT_DATE: 'Die letzte OCT wurde durchgeführt am: {{latest_oct_date}}',
    LABEL_WITHDRAWAL_WILL_OCCUR_AFTER_SUBMISSION: 'Bitte beachten: Die Änderung des OCT Diagnostik Arzt wird erst aktiv, wenn Sie diese Behandlung zur Abrechnung übermitteln.',
    LABEL_PLEASE_ENTER_PASSWORD_TO_REJECT_OCT: 'Bitte geben Sie ihr Passwort ein, um die OCT abzulehnen.',
    LABEL_OCT_REJECTION_SUCCESSFUL: 'OCT abgelehnt',
    LABEL_OCT_PATIENT_NAME: 'Nachname, Vorname',
    LABEL_REJECTED_OCTS: 'abgelehnte OCTs: {{number_of_rejected_octs}}',
    LABEL_NO_OCT_DATE: 'keine OCT durchgeführt',
    LABEL_NO_OPEN_OCTS_LEFT: 'alle verbraucht',
    LABEL_OCT_PENDING: 'Weitere OCTs können erst nach der Durchführung der ersten IVOM abgerechnet werden.',
    LABEL_PENDING_OCTS: 'vorgemerkt',
    LABEL_REJECTED: 'Nicht zugewiesen',
    LABEL_OCT_DOCTOR_UPDATED: 'OCT Arzt bearbeitet',
    LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_OCT: 'Ich übernehme die Verantwortung für die korrekte Durchführung der SD-OCT-Diagnostik und für die Weiterleitung der digitalen Befunddatei sowie der digitalen schriftlichen Auswertung an den operierenden Arzt.',
    LABEL_OCT_ALREADY_EXIST: 'Für den selben Tag und die selbe Lokalisation existiert breits eine OCT.',
    //***STATUS***//
    OCT1: 'offen',
    OCT3: 'überfällig',
    OCT4: 'zurückgezogen',
    OCT5: 'alle verbraucht',
    OCT6: 'vorgemerkt',

    //***VALIDATIONS***//
    LABEL_CANT_SUBMIT_OCT_IN_FUTURE: 'Das Datum ({{date}}) liegt in der Zukunft.',
    LABEL_OCT_BEFORE_FIRST_OP_ALREADY_EXISTS: 'Nur eine OCT ({{first_oct_date}}) kann vor der ersten IVOM abgerechnet werden ({{date}}).',
    LABEL_PATIENT_HAS_NO_CONSENT_ON_AN_OCT_CONTRACT: 'Der Patient {{name}} hat keine Teilnahmeerklärung für das Datum ({{date}}).',
    LABEL_DOCTOR_HAS_NO_CONSENT_ON_AN_OCT_CONTRACT: 'Der Arzt {{name}} hat keine Teilnahmeerklärung für das Datum ({{date}}).',
    LABEL_DOCTOR_HAS_NO_VALID_CONSENT_ON_AN_OCT_CONTRACT: 'Der Arzt {{name}} hat keine Teilnahmeerklärung für das Datum ({{date}}).',
    LABEL_PATIENT_HAS_NO_VALID_CONSENT_ON_AN_OCT_CONTRACT: 'Der Patient {{name}} hat keine Teilnahmeerklärung für das Datum ({{date}}).',
    LABEL_OCT_TOO_FAR_BEFORE_OP: 'Auf Grund des Vertrages mit der Krankenkasse, kann die OCT erst ab dem {{timespan}} durchgeführt werden.',
    LABEL_OCT_DATE_OUTSIDE_OF_SUBMISSION_TIMESPAN: 'Auf Grund des Vertrages mit der Krankenkasse, konnte die OCT nur bis zum {{timespan}} übermittelt werden.',
    LABEL_OCT_COUNT_PER_TREATMENT_YEAR_EXCEEDED: 'Die maximale Anzahl von {{max_count}} OCTs pro Behandlungsjahr wurden bereits abgerechnet. Das nächste Behandlungsjahr beginnt am {{date}}.',
    LABEL_DOCTOR_CAN_ONLY_SUBMIT_OCT_UNTIL_DATE: 'Der OCT Diagnostik Arzt {{name}} kann auf Grund einer Entscheidung des operierenden Arztes nur OCTs bis zum {{date}} abrechnen.',
    LABEL_OCT_MULTI_EDIT_ELIGIBILITY: '{{eligibile_cases}} von {{total_cases}} ausgewählten OCTs werden nicht geändert, da das gewählte Datum nicht gültig ist. Möchten Sie fortfahren?',
    LABEL_NO_OCT_DEVICE_IN_PRACTICE: 'Ihre Praxis verwendet kein SD-OCT Gerät. Bitte bestätigen Sie die Verwendung eines SD-OCT Gerätes in den Einstellungen des Praxis-Accounts.',
    LABEL_NO_VALID_OP_FOR_LOCALIZATION_IN_TREATMENT_YEAR: 'Für das gewählte Datum gibt es für diese Lokalisation keine laufende Behandlung.',
    LABEL_CANT_SUBMIT_OCT_SINCE_IVOM_AUTO_GENERATED: 'Vorgang nicht möglich, da beim Patienten für die Lokalisation nur eine automatisch generierte Dokumentations-IVOM in Medios Connect hinterlegt ist. Bitte überprüfen Sie die Angaben unter "Behandlungen aus dem BDOC Vertrag übertragen" in den Patienten Details.',
    LABEL_NO_VALID_CONSENT_CONTACT_DOCTOR: 'Der Patient {{name}} hat keine Teilnahmeerklärung für das Datum {{date}}. Bitte kontaktieren Sie {{op_doctor_name}} via {{op_doctor_email}} oder {{op_doctor_phone}}, um die Erklärung so schnell wie mölgich zu verlängern. Anderfalls wird der Kostenträger {{hip_name}} den Fall sehr wahrscheinlich ablehnen.',
    LABEL_NO_VALID_CONSENT_CONTACT_DOCTOR_WOE_WOP: 'Der Patient {{name}} hat keine Teilnahmeerklärung für das Datum {{date}}. Bitte kontaktieren Sie {{op_doctor_name}}, um die Erklärung so schnell wie mölgich zu verlängern. Anderfalls wird der Kostenträger {{hip_name}} den Fall sehr wahrscheinlich ablehnen.',
    LABEL_NO_VALID_CONSENT_CONTACT_DOCTOR_WOE_WP: 'Der Patient {{name}} hat keine Teilnahmeerklärung für das Datum {{date}}. Bitte kontaktieren Sie {{op_doctor_name}} via {{op_doctor_phone}}, um die Erklärung so schnell wie mölgich zu verlängern. Anderfalls wird der Kostenträger {{hip_name}} den Fall sehr wahrscheinlich ablehnen.',
    LABEL_NO_VALID_CONSENT_CONTACT_DOCTOR_WE_WOP: 'Der Patient {{name}} hat keine Teilnahmeerklärung für das Datum {{date}}. Bitte kontaktieren Sie {{op_doctor_name}} via {{op_doctor_email}}, um die Erklärung so schnell wie mölgich zu verlängern. Anderfalls wird der Kostenträger {{hip_name}} den Fall sehr wahrscheinlich ablehnen.',
    LABEL_DOCTOR_DONT_HAVE_CREDENTIONALS_FOR_DATE: 'Der Arzt {{name}} hat keine OCT Zertifizierung für das Datum ({{date}}).',
    //***BUTTONS***//
    BUTTON_WITHDRAW_OCTS: 'Ja, OCT zurückziehen',
    BUTTON_CANCEL_OCT_DOCTOR_CHANGE: 'Nein, Änderungen verwerfen',
    BUTTON_REJECT_OCT: 'OCT ablehnen',
    BUTTON_EDIT_OCT_DOCTOR: 'OCT Diagnostik Arzt bearbeiten'
};

var translationsOctEN = {
    //***LABELS***//

    //***BUTTONS***//

};