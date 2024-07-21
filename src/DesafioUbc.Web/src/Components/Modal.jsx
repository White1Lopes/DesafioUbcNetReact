const Modal = ({isOpen, onClose, onConfirm, message}) => {
    if (!isOpen) return null;

    return (
        <div className="fixed inset-0 bg-gray-800 bg-opacity-50 flex items-center justify-center z-50">
            <div className="bg-white p-6 rounded-lg shadow-lg max-w-sm w-full z-60">
                <h3 className="text-lg font-semibold mb-4">{message}</h3>
                <div className="flex justify-end">
                    <button
                        className="bg-red-500 hover:bg-red-600 text-white font-bold py-2 px-4 rounded mr-2"
                        onClick={onConfirm}
                    >
                        Confirmar
                    </button>
                    <button
                        className="bg-gray-500 hover:bg-gray-600 text-white font-bold py-2 px-4 rounded"
                        onClick={onClose}
                    >
                        Cancelar
                    </button>
                </div>
            </div>
        </div>
    );
};

export default Modal;